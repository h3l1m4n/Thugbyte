using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    interface ISearch
    {
      
        List<song> SearchAsync(string searchSong, int index, int russian);


    }
}
