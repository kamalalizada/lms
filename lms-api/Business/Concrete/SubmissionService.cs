using LMS_API.DataAccess.Concrete.EntityFramework;
using LMS_API.Entity.Concrete;
using LMS_API.Entity.Dto;
using System;

namespace LMS_API.Business.Concrete;

public class SubmissionService
{

    private readonly ISubmissionDal _submissionDal;

    public SubmissionService(ISubmissionDal submissionDal)
    {
        _submissionDal = submissionDal;
    }

    public async Task SubmissionAsync(SubmissionCreateDto dto)
    {
        string filePath = null;

        if(dto.File != null)
        {
            var allowed = new[]
            {
                ".pdf",".zid",".png",".jpg",".jpeg"
            };

            var ext = Path.GetExtension(dto.File.FileName).ToLower();

            if(!allowed.Contains(ext))
            {
                throw new Exception("File type not allowed.");

            }

            if(dto.File.Length>10*1024*1024)
            {
                throw new Exception("File too large.");
            }

            var folder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Submissions");
            Directory.CreateDirectory(folder);

            string fileName = $"{Guid.NewGuid()}{ext}";
            filePath= Path.Combine(folder, fileName);

            using (var stream = new FileStream(filePath,FileMode.Create))
            {
                await dto.File.CopyToAsync(stream);
            }
        }

        var submission = new Submission
        {
            AssingmentId = dto.AssignmentId,
            StudentId = dto.StudentId,
            Content = dto.Content,
            FilePath = filePath,
            SubmittedAt = DateTime.UtcNow,
            Status = "Pending"
        };

       _submissionDal.AddAsync(submission);
    }
}
