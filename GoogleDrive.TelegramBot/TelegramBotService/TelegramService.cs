using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleDrive.Data;

namespace GoogleDrive.TelegramBot.TelegramBotService;

public class TelegramService
{
    public TelegramService()
    {
        var appDb = new AppDbContext();
    }
}
