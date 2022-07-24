using System.Collections;

namespace DesafioImpar.Application.ViewModels
{
    public class ODataViewModel
    {
        public long? Total { get; private set; }

        public IEnumerable Items { get; private set; }

        public ODataViewModel(long? total, IEnumerable items)
            => (Total, Items) = (total, items);


    }
}
