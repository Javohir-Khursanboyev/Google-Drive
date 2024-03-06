using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDrive.Models;

public class ContentModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime SetTime { get; set; }
    public long UserId { get; set; }
    public long AlbumId { get; set; }
}
