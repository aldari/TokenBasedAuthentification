using System.Collections.Generic;
using System.Linq;
using ParrotWingsTransfer.API.Models;
using ParrotWingsTransfer.CqsDataModel.Transfer.Dto;
using ParrotWingsTransfer.CqsDataModel.Transfer.Query;
using ParrotWingsTransfer.EFDataAccess.Core;

namespace ParrotWingsTransfer.EFDataAccess.Transfer.Query
{
    public class GetTemplateMatchNamesQuery : EfQueryBase<AuthContext>, IGetTemplateMatchNamesQuery
    {
        public GetTemplateMatchNamesQuery(AuthContext context)
            : base(context)
        {
        }

        public List<AppUserDto> Execute(string template)
        {
            return DbContext.Users.Where(s=>s.Fullname.Contains(template)).Select(x=>new AppUserDto { Id = x.Id, Name = x.Fullname}).ToList();
        }
    }
}
