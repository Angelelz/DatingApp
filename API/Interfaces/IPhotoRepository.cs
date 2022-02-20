using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<PhotoForApprovalDto>> GetUnapprovedPhotos();
        Task<Photo> GetPhotoById(int id);
        Task RemovePhoto(int id);
        Task<bool> ApprovePhoto(int id);
        Task<IEnumerable<Photo>> GetAllPhotosFromUser(int id);
    }
}