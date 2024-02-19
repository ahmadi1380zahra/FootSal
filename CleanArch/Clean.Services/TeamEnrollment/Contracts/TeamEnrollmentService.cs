using Clean.Services.TeamEnrollment.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Services.TeamEnrollment.Contracts
{
    public interface TeamEnrollmentService
    {
        Task Add(AddEnrollmentDto dto);
    }
}
