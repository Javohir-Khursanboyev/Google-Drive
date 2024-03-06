using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleDrive.Domain.Commons;

namespace GoogleDrive.Models;

public class AlbumModel : Auditable
{
    public string Name { get; set; }
    public long UserId { get; set; }
}
