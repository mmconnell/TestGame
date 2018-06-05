using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager
{
    public class ToolEnumList
    {
        public AbstractTool[] list;

        public ToolEnumList()
        {
            list = new AbstractTool[InformationManager.GetMaxTools()];
        }

        public AbstractTool Get(ToolEnum toolEnum)
        {
            if (toolEnum == null)
            {
                return null;
            }
            return list[toolEnum.IntValue];
        }

        public void Add(ToolEnum toolEnum, AbstractTool tool)
        {
            if (toolEnum != null)
            {
                list[toolEnum.IntValue] = tool;
            }
        }

        public void Remove(ToolEnum toolEnum)
        {
            if (toolEnum != null)
            {
                list[toolEnum.IntValue] = null;
            }
        }
    }
}
