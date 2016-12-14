using System.Collections.Generic;
using ParrotWingsTransfer.CqsDataModel.CqsCore;
using ParrotWingsTransfer.CqsDataModel.Transfer.Dto;

namespace ParrotWingsTransfer.CqsDataModel.Transfer.Query
{
    public interface IGetTemplateMatchNamesQuery : IQuery
    {
        List<AppUserDto> Execute(string template);
    }
}
