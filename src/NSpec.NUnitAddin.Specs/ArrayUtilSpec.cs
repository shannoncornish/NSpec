using NUnit.Framework;

namespace NSpec.NUnitAddin.Specs
{
    public class ArrayUtilSpec : Spec
    {
        [Test]
        public void add_should_add_item_to_end_of_array_when_given_existing_array()
        {
            var array = new[] { 1, 2, 3 };

            ArrayUtil.Add(ref array, 4);

            specify(() => array[2] == 3);
            specify(() => array[3] == 4);
            specify(() => array.Length == 4);
        }
    }
}