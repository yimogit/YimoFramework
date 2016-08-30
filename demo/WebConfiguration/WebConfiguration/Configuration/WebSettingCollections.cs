using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebConfiguration.Configuration
{
    [ConfigurationCollection(typeof(WebSettingElement))]
    public partial class WebSettingCollections : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new WebSettingElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((WebSettingElement)element).Name;
        }
        public new WebSettingElement this[string name]
        {
            get
            {
                return (WebSettingElement)this.BaseGet(name);
            }
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

    }
}
