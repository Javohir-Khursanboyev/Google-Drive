using GoogleDrive.Data.AppDbContexts;
using GoogleDrive.Domain.Entities.Contents;
using GoogleDrive.Domain.Entities.Users;
using GoogleDrive.Service.Extensions;
using GoogleDrive.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using static System.Net.Mime.MediaTypeNames;

namespace GoogleDrive.Service.Service;

public class TelegramBotService
{
    TelegramBotClient botClient;
    UserService userService;
    AppDbContext appDbContext;
    UserViewModel existUser;
    ContentService contentService;
    public TelegramBotService(AppDbContext appDbContext, UserService userService, ContentService contentService)
    {
        this.botClient = new TelegramBotClient("6791483512:AAHXmxeGLbqc5lR4JnrX2qzzLyMrvF6C-gM");
        this.userService = userService;
        this.appDbContext = appDbContext;
        this.contentService = contentService;
    }

    public async Task Run()
    {
        await botClient.ReceiveAsync(Update, Error);
        Console.ReadLine();
    }
    private async Task Update(ITelegramBotClient client, Update update, CancellationToken token)
    {
        var message = update.Message;
        existUser = await userService.CreateAsync(new UserCreationModel
        {
            FirstName = message.Chat.FirstName,
            LastName = message.Chat.LastName,
            ChatId = message.Chat.Id.ToString()
        });
        await Console.Out.WriteLineAsync(message?.Chat.Id.ToString());
        if (message?.Text == "/start")
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, $"Hi {message?.Chat?.FirstName?.ToString()}, " +
                $"Welcome to our Free Cloud Memeory");
            var rkm = new ReplyKeyboardMarkup(new KeyboardButton("Choice"));
            rkm.Keyboard =
                 new KeyboardButton[][]
                 {
                    new KeyboardButton[]
                    {
                        new KeyboardButton("Pictures"),
                        new KeyboardButton("My Albums")
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton("My contact details")
                    }
                 };
            await client.SendTextMessageAsync(message.Chat.Id, "Menu", replyMarkup: rkm);

        }
        if (message?.Text?.ToLower() == "my contact details")
        {
            await client.SendTextMessageAsync(message.Chat.Id, $"{existUser.FirstName} | {existUser.LastName}");
            //await client.SendTextMessageAsync(message.Chat.Id, $"First name: {message.Chat.FirstName}");
            //await client.SendTextMessageAsync(message.Chat.Id, $"Last name: {message.Chat.LastName}");
        }
        if (message?.Text?.ToLower() == "pictures")
        {
            var picturesChoice = new ReplyKeyboardMarkup(new KeyboardButton("Choice"));
            picturesChoice.Keyboard = new KeyboardButton[][]
                 {
                    new KeyboardButton[]
                    {
                        new KeyboardButton("My pictures"),
                        new KeyboardButton("Upload")
                    }
                 };
            await client.SendTextMessageAsync(message.Chat.Id, "Menu", replyMarkup: picturesChoice);
        }
        if (message?.Text?.ToLower() == "albums")
        {

        }
        if (message?.Text?.ToLower() == "upload")
        {
            await client.SendTextMessageAsync(message.Chat.Id, "Send your picture");
        }
        if(message.Document != null)
        {
            var file = await client.GetFileAsync(message.Document.FileId);
            FileStream fs = new FileStream($@"..\..\..\..\GoogleDrive.Domain\Images\testImage_{message.Chat.Id}", FileMode.Create,FileAccess.Write);
            await client.DownloadFileAsync(file.FilePath, fs);
            ContentCreationModel content = new ContentCreationModel()
            {
                UserId = existUser.Id,
            };

            fs.Close();
            fs.Dispose();

            using (var stream = new FileStream($@"..\..\..\..\GoogleDrive.Domain\Images\testImage_{message.Chat.Id}", FileMode.Open, FileAccess.Read))
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                content.ImageDates = memoryStream.ToArray();
            }
            await contentService.CreateAsync(content);

            using (StreamWriter sw = new StreamWriter($@"..\..\..\..\GoogleDrive.Domain\Images\testImage_{message.Chat.Id}", false))
            {
                await sw.WriteAsync("");
            }
        }
        if(message?.Text?.ToLower() == "my pictures")
        {
            var pictures = await contentService.GetAllAsync(existUser.Id);
            foreach(var picture in pictures)
            {
                StreamWriter sw = new StreamWriter($@"..\..\..\..\GoogleDrive.Domain\Images\testImage_{message.Chat.Id}", false);
                sw.Write(picture.ImageDates);
                sw.Close();
                await using Stream stream = System.IO.File.OpenRead($@"..\..\..\..\GoogleDrive.Domain\Images\testImage_{message.Chat.Id}");
                await client.SendDocumentAsync(message.Chat.Id, new InputFileStream(stream, "Image.png"));

            }
        }
    }
    private Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}