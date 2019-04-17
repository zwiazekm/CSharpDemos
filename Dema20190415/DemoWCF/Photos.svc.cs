using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DemoDB;

namespace DemoWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Photos : IPhotos
    {
        PhotoContext photoDb = new PhotoContext();

        public Photo GetPhoto(int photoId)
        {
            var photo = (from p in photoDb.Photos
                        where p.PhotoID == photoId
                        select p).Single();
            return photo;
        }

        public IEnumerable<Photo> PhotoList()
        {
            return (from p in photoDb.Photos
                    select p).ToList();
        }

        public void SetPhoto(Photo photo)
        {
            photoDb.Photos.Add(photo);
            photoDb.SaveChanges();
        
        }
    }
}
