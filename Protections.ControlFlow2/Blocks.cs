using System.Collections.Generic;
using System.Linq;
using ICore;

namespace Protections.ControlFlow2
{
	public class Blocks
	{
		public List<Block> blocks = new List<Block>();

		public Block getBlock(int id)
		{
			return blocks.Single((Block block) => block.ID == id);
		}

		public void Scramble(out Blocks incGroups)
		{
			Blocks blocks = new Blocks();
			foreach (Block block in this.blocks)
			{
				blocks.blocks.Insert(Utils.rnd.Next(blocks.blocks.Count), block);
			}
			incGroups = blocks;
		}
	}
}
