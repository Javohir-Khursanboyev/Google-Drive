using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleDrive.Models.ContentModels;

public class ContentCreationModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }
    public long AlbumId { get; set; }
}
