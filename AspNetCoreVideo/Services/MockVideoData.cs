using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVideo.Entities;

namespace AspNetCoreVideo.Services
{
    public class MockVideoData : IVideoData
    {
        private IEnumerable<Video> _videos;


        public MockVideoData()
        {
            _videos = new List<Video> {
            new Video{ Id = 1, GenreId = 1, Title = "Shrek" },
            new Video{ Id = 2,GenreId = 2, Title = "Shrek2" },
            new Video{ Id = 2,GenreId = 3, Title = "Shrek3" }
            };
        }

        public Video Get(int id)
        {
            return _videos.FirstOrDefault(v => v.Id.Equals(id));
        }

        public IEnumerable<Video> GetAll()
        {
            return _videos;
        }
    }
}
