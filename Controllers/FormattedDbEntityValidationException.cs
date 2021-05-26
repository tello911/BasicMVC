using System.Data.Entity.Validation;

namespace GeeksForGeeks.Controllers
{
    internal class FormattedDbEntityValidationException
    {
        private DbEntityValidationException e;

        public FormattedDbEntityValidationException(DbEntityValidationException e)
        {
            this.e = e;
        }
    }
}