using BCOAPI.Core.Domain.Dtos;
using BCOAPI.Core.Domain.Responses;
using BCOAPI.Core.Interfaces;
using BCOAPI.Core.Validator;
using FluentValidation.Results;
using System.Net;

namespace BCOAPI.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public TransactionResponse compraTarjeta(cargoDto model)
        {
            TransactionResponse response = new TransactionResponse();
            try
            {
                string MyErrors = "";
                cargoValidator cargoVal = new cargoValidator();
                ValidationResult result = cargoVal.Validate(model);
                if (!result.IsValid)
                {
                    foreach (var errors in result.Errors)
                    {
                        MyErrors += string.Format("[ {0} - {1} ] ", errors.PropertyName, errors.ErrorMessage);
                    }
                    response.IsSuccess = false;
                    response.Status = new ResponseStatus { HttpCode = HttpStatusCode.BadRequest, Message = MyErrors };
                }
                else
                {
                    var newModel = _unitOfWork.mapper.Map<BCOAPI.Domain.Dtos.cargoDto>(model);
                    bool resp = _unitOfWork.cargoRepository.compraTarjeta(newModel);
                    response.IsSuccess = resp;
                    response.Status = new ResponseStatus { HttpCode = HttpStatusCode.OK, Message = "OK" };
                }
                
            }
            catch (Exception)
            {
                response.Status = new ResponseStatus { HttpCode = HttpStatusCode.BadRequest, Message = "Error en la consulta" };
                response.IsSuccess = false;
            }
            return response;
        }

        public TransactionResponse pagoTarjeta(abonoDto model)
        {
            TransactionResponse response = new TransactionResponse();
            try
            {
                string MyErrors = "";
                abonoValidator cargoVal = new abonoValidator();
                ValidationResult result = cargoVal.Validate(model);
                if (!result.IsValid)
                {
                    foreach (var errors in result.Errors)
                    {
                        MyErrors += string.Format("[ {0} - {1} ] ", errors.PropertyName, errors.ErrorMessage);
                    }
                    response.IsSuccess = false;
                    response.Status = new ResponseStatus { HttpCode = HttpStatusCode.BadRequest, Message = MyErrors };
                }
                else
                {
                    var newModel = _unitOfWork.mapper.Map<BCOAPI.Domain.Dtos.abonoDto>(model);
                    bool resp = _unitOfWork.abonoRepository.pagoTarjeta(newModel);
                    response.IsSuccess = resp;
                    response.Status = new ResponseStatus { HttpCode = HttpStatusCode.OK, Message = "OK" };
                }

            }
            catch (Exception)
            {
                response.Status = new ResponseStatus { HttpCode = HttpStatusCode.BadRequest, Message = "Error en la consulta" };
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
