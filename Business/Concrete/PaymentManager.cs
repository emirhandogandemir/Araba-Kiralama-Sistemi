using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public  class PaymentManager : IPaymentService
    {
        public IResult CardPaymentAdd(CardPayment card)
        {
            return card.Number != "0123456789"
                ? (IResult)new ErrorResult(Messages.PaymentError)
                : new SuccessResult(Messages.PaymentSuccess);
        }
    }
}
