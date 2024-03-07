using GoogleDrive.Data.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace GoogleDrive.Service.Service;

public class TelegramBotService
{
    TelegramBotClient botClient;
    public TelegramBotService(AppDbContext appDbContext)
    {
        this.botClient = new TelegramBotClient("6791483512:AAHXmxeGLbqc5lR4JnrX2qzzLyMrvF6C-gM");
    }
}
