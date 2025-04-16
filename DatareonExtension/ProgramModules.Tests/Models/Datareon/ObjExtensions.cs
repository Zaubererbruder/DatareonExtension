using SystemModels;

namespace ProgramModules.Tests.Models
{
    public static class ObjExtensions
    {
        /// <summary>
        /// Проверка пустого значения
        /// </summary>
        public static bool IsNullOrDefault<T>(this T __core_item)
        {
            return ExpressionsUtils.IsNullOrDefault<T>(__core_item);
        }
    }
}
