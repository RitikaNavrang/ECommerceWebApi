using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface;

public interface IFileManagerLogic
{
    public Task<string> Upload(FileModel model);
    public Task<byte[]> Get(string imageName);
}
