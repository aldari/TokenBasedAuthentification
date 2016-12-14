using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using ParrotWingsTransfer.CqsDataModel.Transfer.Command;
using ParrotWingsTransfer.CqsDataModel.Transfer.Dto;
using ParrotWingsTransfer.CqsDataModel.Transfer.Query;
using ParrotWingsTransfer.EFDataAccess.Transfer.Command;

namespace ParrotWingsTransfer.API.Controllers
{
    public class TransferController : ApiController
    {
        private readonly IGetTemplateMatchNamesQuery _getTemplateMatchNamesQuery;
        private readonly AddTransactionCommandHandler _addTransactionCommandHandler;

        public TransferController(IGetTemplateMatchNamesQuery getTemplateMatchNamesQuery, AddTransactionCommandHandler addTransactionCommandHandler)
        {
            _getTemplateMatchNamesQuery = getTemplateMatchNamesQuery;
            _addTransactionCommandHandler = addTransactionCommandHandler;
        }

        public UserList Get(string id)
        {
            return new UserList { Users = _getTemplateMatchNamesQuery.Execute(id) };
        }

        public IHttpActionResult Post(TransferModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var command = new AddTransactionCommand(User.Identity.GetUserId(), model.Correspondent, model.Amount);
                    _addTransactionCommandHandler.Execute(command);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                //todo filter
                return BadRequest("");
            }
        }
    }

    public class UserList
    {
        public List<AppUserDto> Users { get; set; }
    }

    public class TransferModel
    {
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Correspondent { get; set; }
    }
}
