using CertificateManagementApi.Dtos;
using CertificateManagementApi.Model;
using CertificateManagementApi.Repository.Interface;
using CertificateManagementApi.Service.Interface;

namespace CertificateManagementApi.Service.Implementation
{
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IWebHostEnvironment _webHost;
        public CertificateService(ICertificateRepository certificateRepository, IWebHostEnvironment webHost)
        {
            _certificateRepository = certificateRepository;
            _webHost = webHost;
        }
        public async Task<BaseResponse<CertificateDto>> Create(CreateCertificateRequestModel model, int OrganizationId)
        {
            var certificate = new Certificate
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Date = model.Date,
                 OrganizationId = OrganizationId,
            };

            await _certificateRepository.Create(certificate);

            string SignatureImage = null;

            if (model.Signature != null)
            {
                var uploadsFolder = Path.Combine(_webHost.WebRootPath, "Signature");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetFileName(model.Signature.FileName);
                SignatureImage = "/Signature/" + fileName;
                var filePath = Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Signature.CopyToAsync(stream);
                }
            }
            certificate.Signature = SignatureImage;

            await _certificateRepository.Update(certificate);
            return new BaseResponse<CertificateDto>
            {
                Message = "Certificate created successfully",
                Status = true,
            };
        }

        public async Task<bool> Delete(int id)
        {
            var admin = await _certificateRepository.Get(id);
            if (admin != null)
            {
                admin.isDeleted = true;
                return true;
            }
            return false;
        }

        public async Task<CertificateResponseModel> Get(int id)
        {
            var certificate = await _certificateRepository.Get(id);
            if (certificate == null)
            {
                return new CertificateResponseModel
                {
                    Message = "Certificate not found",
                    Status = false,
                    Data = null
                };
            }
            return new CertificateResponseModel
            {
                Message = "Successfully",
                Status = true,
                Data = new CertificateDto
                {
                    FirstName = certificate.FirstName,
                    LastName = certificate.LastName,
                    Date = certificate.Date,
                    Signature = certificate.Signature,
                }
            };
        }

        public async Task<CertificatesResponseModels> GetAll()
        {
            var certificates = await _certificateRepository.GetAll();
            if (certificates == null)
            {
                return new CertificatesResponseModels
                {
                    Message = "No certificate exist",
                    Status = false,
                    Data = null
                };
            }
            var listOfCertificates = certificates.ToList().Select(certificate => new CertificateDto
            {
                isGenerated = certificate.isGenerated,
                Id = certificate.Id,
                FirstName = certificate.FirstName,
                LastName = certificate.LastName,
                Date = certificate.Date,
                Signature = certificate.Signature,
            }).ToList();
            return new CertificatesResponseModels
            {
                Message = "Successful",
                Status = true,
                Data = listOfCertificates
            };
        }

        public async Task<CertificatesResponseModels> GetAllGeneratedCertificates()
        {
            var certificates = await _certificateRepository.GetAllGeneratedCertificates();
            if (certificates == null) return new CertificatesResponseModels
            {
                Message = "Certificate is null",
                Status = false,
                Data = null
            };

            var listOfCertificates = certificates.Select(certificate => new CertificateDto
            {
                Id = certificate.Id,
                isGenerated = certificate.isGenerated,
                FirstName = certificate.FirstName,
                LastName = certificate.LastName,
                Date = certificate.Date,
                Signature = certificate.Signature,
            }).ToList();
            return new CertificatesResponseModels
            {
                Message = "ok",
                Status = true,
                Data = listOfCertificates
            };
        }

        public async Task<CertificatesResponseModels> GetAllUnGeneratedCertificates(int organizationId)
        {
            var certificates = await _certificateRepository.GetAllUngeneratedCertificates(organizationId);
            if (certificates == null) return new CertificatesResponseModels
            {
                Message = "certificate is null",
                Status = false,
                Data = null
            };

            
            var listOfCertificates = certificates.Select(certificate => new CertificateDto
            {
                Id = certificate.Id,
                isGenerated = certificate.isGenerated,
                FirstName = certificate.FirstName,
                LastName = certificate.LastName,
                Date = certificate.Date,
                Signature = certificate.Signature,

            }).ToList();
            foreach(var certificate in certificates)
            {
                certificate.isGenerated = true;
            }
             await _certificateRepository.UpdateCertToTrue(certificates);
        
            
            return new CertificatesResponseModels
            {
                Message = "ok",
                Status = true,
                Data = listOfCertificates
            };
        }
        // public async Task<BaseResponse<CertificateDto>> UpdateList(List<int> ids)
        // {
            
        // }
        public async Task<BaseResponse<CertificateDto>> Update(UpdateCertificateRequestModel model, int id)
        {
            var certificate = await _certificateRepository.Get(a => a.Id == id);
            if (certificate == null) return new BaseResponse<CertificateDto>
            {
                Message = "Certificate not found",
                Status = false,
                Data = null
            };
            string SignatureImage = null;

            if (model.Signature != null)
            {
                var uploadsFolder = Path.Combine(_webHost.WebRootPath, "Signature");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetFileName(model.Signature.FileName);
                SignatureImage = "/Signature/" + fileName;
                var filePath = Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Signature.CopyToAsync(stream);
                }
            }

            certificate.FirstName = model.FirstName;
            certificate.LastName = model.LastName;
            certificate.Date = model.Date;
            certificate.Signature = SignatureImage;

            await _certificateRepository.Update(certificate);

            return new BaseResponse<CertificateDto>
            {
                Message = "Certificate updated successfully",
                Status = true,
            };
        }
    }
}