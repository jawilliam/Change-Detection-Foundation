//using Microsoft.CodeAnalysis;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Jawilliam.CDF.Approach.GumTree
//{
//    public class PriorityTreeList
//    {
//        public virtual int MinHeight { get; set; } = 1;

//        private List<SyntaxNode>[] trees;

//        private int maxHeight;

//        private int currentIdx;

//        public PriorityTreeList(SyntaxNode tree)
//        {
//            int listSize = tree.Height(t => t.ChildNodes(), ) - MinHeight + 1;
//            if (listSize < 0)
//                listSize = 0;
//            if (listSize == 0)
//                currentIdx = -1;
//            trees = (List<SyntaxNode>[])new ArrayList[listSize];
//            maxHeight = tree.getHeight();
//            addTree(tree);
//        }

//        private int idx(SyntaxNode tree)
//        {
//            return idx(tree.getHeight());
//        }

//        private int idx(int height)
//        {
//            return maxHeight - height;
//        }

//        private int height(int idx)
//        {
//            return maxHeight - idx;
//        }

//        private void addTree(SyntaxNode tree)
//        {
//            if (tree.getHeight() >= this.MinHeight)
//            {
//                int idx = idx(tree);
//                if (trees[idx] == null) trees[idx] = new ArrayList<>();
//                trees[idx].add(tree);
//            }
//        }

//        public List<SyntaxNode> open()
//        {
//            List<SyntaxNode> pop = pop();
//            if (pop != null)
//            {
//                for (SyntaxNode tree: pop) open(tree);
//                updateHeight();
//                return pop;
//            }
//            else return null;
//        }

//        public List<SyntaxNode> pop()
//        {
//            if (currentIdx == -1)
//                return null;
//            else
//            {
//                List<SyntaxNode> pop = trees[currentIdx];
//                trees[currentIdx] = null;
//                return pop;
//            }
//        }

//        public void open(SyntaxNode tree)
//        {
//            for (SyntaxNode c: tree.getChildren()) addTree(c);
//        }

//        public int peekHeight()
//        {
//            return (currentIdx == -1) ? -1 : height(currentIdx);
//        }

//        public void updateHeight()
//        {
//            currentIdx = -1;
//            for (int i = 0; i < trees.length; i++)
//            {
//                if (trees[i] != null)
//                {
//                    currentIdx = i;
//                    break;
//                }
//            }
//        }
//    }
//}
