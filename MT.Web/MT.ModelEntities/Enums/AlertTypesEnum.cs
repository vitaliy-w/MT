using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.ModelEntities.Enums
{
    
    /// <summary>
    /// AlertTypesEnum указывает на тип сообщения для пользователя.
    /// Succes указывает на то, что действие прошло успешно.
    /// Warning указывает на некритичные ошибки.
    /// Danger указывает на критичные ошибки.
    ///  </summary>

    public enum AlertTypesEnum
    {
        Succes = 1,
        Warning = 2,
        Danger = 3
    }
}
