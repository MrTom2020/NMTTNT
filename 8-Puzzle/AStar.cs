﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_Puzzle
{
    class NodeAStar
    {
        private Int16[,] PuzzleClass;
        private UInt64 NodeNumber;
        private UInt32 NodeDepth;
        private int Depth;
        private int fn;
        private string ActionClass;
        private NodeAStar Next;
        private NodeAStar Back;
        private NodeAStar Parent;
        public NodeAStar()
        {
            PuzzleClass = null;
            ActionClass = null;
            Next = null;
            Parent = null;
        }
        //********************* 
        public NodeAStar(Int16[,] element)
        {
            PuzzleClass = element;
            ActionClass = null;
            Next = null;
            Parent = null;
        }
        //********************
        public NodeAStar(Int16[,] element, string act, NodeAStar prnt)
        {
            PuzzleClass = element;
            ActionClass = act;
            Next = null;
            Parent = prnt;
        }
        //********************
        public Int16[,] PuzzleCLASS
        {
            get
            {
                return PuzzleClass;
            }
            set
            {
                PuzzleClass = value;
            }

        }

        public string ActionCLASS
        {
            get
            {
                return ActionClass;
            }
            set
            {
                ActionClass = value;
            }

        }
        public NodeAStar NEXT
        {
            get
            {
                return Next;
            }
            set
            {
                Next = value;
            }

        }
        public NodeAStar BACK
        {
            get
            {
                return Back;
            }
            set
            {
                Back = value;
            }

        }
        public NodeAStar PARENT
        {
            get
            {
                return Parent;
            }
            set
            {
                Parent = value;
            }

        }
        public UInt64 NodeNUMBER
        {
            get
            {
                return NodeNumber;
            }
            set
            {
                NodeNumber = value;
            }

        }
        public UInt32 NodeDEPTH
        {
            get
            {
                return NodeDepth;
            }
            set
            {
                NodeDepth = value;
            }

        }

        public int Fn
        {
            get
            {
                return fn;
            }
            set
            {
                fn = value;
            }

        }
        public int DEPTH
        {
            get
            {
                return Depth;
            }
            set
            {
                Depth = value;
            }

        }

    }//end of class NodeIds

    //*****************************************************
    class PQueue
    {
        private static NodeAStar rear;
        private static NodeAStar front;
        public static UInt64 count = 0;

        public PQueue() { }

        public void Enqueue(Int16[,] pzl, string act, NodeAStar parent, int hn)
        {
            NodeAStar newNode = new NodeAStar(pzl, act, parent);
            if (parent != null)
            {
                newNode.DEPTH = parent.DEPTH + 1;
                newNode.Fn = newNode.DEPTH + hn;
            }
            

            if (rear == null)
            {
                newNode.DEPTH = 0;
                newNode.Fn = hn;
                front = newNode;
                newNode.NodeNUMBER = count;
                rear = front;

            }
            else
            {
                NodeAStar Current = front;

                while (newNode.Fn > Current.Fn && Current.NEXT != null)
                {
                    Current = Current.NEXT;
                }

                if (Current.BACK == null && Current.NEXT == null)
                {
                    newNode.DEPTH = parent.DEPTH + 1;
                    newNode.Fn = newNode.DEPTH + hn;
                    front = newNode;
                    front.NEXT = Current;
                    Current.BACK = front;
                    rear = front.NEXT;
                }
                else if (Current.BACK == null && Current.NEXT != null)
                {
                    newNode.DEPTH = parent.DEPTH + 1;
                    front = newNode;
                    front.NEXT = Current;
                    Current.BACK = front;
                }
                else if (Current.NEXT == null && newNode.Fn > Current.Fn)
                {
                    newNode.DEPTH = parent.DEPTH + 1;
                    Current.NEXT = newNode;
                    newNode.BACK = Current;
                    rear = newNode;
                }
                else
                {
                    newNode.DEPTH = parent.DEPTH + 1;
                    newNode.NEXT = Current;
                    Current.BACK.NEXT = newNode;
                    newNode.BACK = Current.BACK;
                    Current.BACK = newNode;
                }
                newNode.NodeNUMBER = count;

            }
            count++;
        }
        public NodeAStar Dequeue()
        {
            if (front == null)
            {
                throw new Exception("Queue is Empty");
            }
            NodeAStar result = front;
            front = front.NEXT;
            return result;
        }

        public NodeAStar Peek()
        {
            if (front == null)
            {
                throw new Exception("Queue is Empty");
            }
            NodeAStar result = front;
            return result;
        }
        void InsertionSort(NodeAStar Node)
        {
            NodeAStar Current = front;

            while (Node.Fn < Current.Fn || Current.NEXT != null)
            {
                Current = Current.NEXT;
            }

            if (Current.NEXT == null)
            {
                Current.NEXT = Node;
            }
            else
            {
                Node.NEXT = Current.NEXT;
                Current.NEXT = Node;
            }
        }
        public void Clear()
        {
            front = rear = null;
            
        }
        public NodeAStar Front
        {
            get
            {
                return front;
            }
            set
            {
                front = value;
            }

        }
        public NodeAStar Rear
        {
            get
            {
                return rear;
            }
            set
            {
                rear = value;
            }

        }

    }//end of class PQueue
    class AStar
    {
        PQueue Pqueue = new PQueue();
        public Int16[,] puzzleIDS = new Int16[3, 3];
        public List<string> PathList = new List<string>();
        public List<UInt64> NodeNumber = new List<UInt64>();
        public int i = 0, j = 0;

        //*****************************************************

        public void PuzzleArrayFunc(Button btn1, Button btn2, Button btn3, Button btn4, Button btn5, Button btn6, Button btn7, Button btn8, Button btn9)
        {

            if (btn1.Text == "")
            {
                puzzleIDS[0, 0] = 0;
                btn1.BackgroundImage = Properties.Resources.kk;
            }
            else
            {
                puzzleIDS[0, 0] = Convert.ToInt16(btn1.Text);
                btn1.BackgroundImage = Properties.Resources._1;
            }

            if (btn2.Text == "")
            {
                puzzleIDS[0, 1] = 0;
                btn2.BackgroundImage = Properties.Resources.kk;
            }
            else
            {
                puzzleIDS[0, 1] = Convert.ToInt16(btn2.Text);
                btn2.BackgroundImage = Properties.Resources._2;
            }

            if (btn3.Text == "")
            {
                puzzleIDS[0, 2] = 0;
                btn3.BackgroundImage = Properties.Resources.kk;
            }
            else
            {
                puzzleIDS[0, 2] = Convert.ToInt16(btn3.Text);
                btn3.BackgroundImage = Properties.Resources._3;
            }

            if (btn4.Text == "")
            {
                puzzleIDS[1, 0] = 0;
                btn4.BackgroundImage = Properties.Resources.kk;
            }
            else
            {
                puzzleIDS[1, 0] = Convert.ToInt16(btn4.Text);
                btn4.BackgroundImage = Properties.Resources._4;
            }

            if (btn5.Text == "")
            {
                puzzleIDS[1, 1] = 0;
                btn5.BackgroundImage = Properties.Resources.kk;
            }
            else
            {
                puzzleIDS[1, 1] = Convert.ToInt16(btn5.Text);
                btn5.BackgroundImage = Properties.Resources._5;
            }

            if (btn6.Text == "")
            {
                puzzleIDS[1, 2] = 0;
                btn6.BackgroundImage = Properties.Resources.kk;
            }
            else
            {
                puzzleIDS[1, 2] = Convert.ToInt16(btn6.Text);
                btn6.BackgroundImage = Properties.Resources._6;
            }

            if (btn7.Text == "")
            {
                puzzleIDS[2, 0] = 0;
                btn7.BackgroundImage = Properties.Resources.kk;
            }
            else
            {
                puzzleIDS[2, 0] = Convert.ToInt16(btn7.Text);
                btn7.BackgroundImage = Properties.Resources._7;
            }

            if (btn8.Text == "")
            {
                puzzleIDS[2, 1] = 0;
                btn8.BackgroundImage = Properties.Resources.kk;
            }
            else
            {
                puzzleIDS[2, 1] = Convert.ToInt16(btn8.Text);
                btn8.BackgroundImage = Properties.Resources._8;
            }

            if (btn9.Text == "")
            {
                puzzleIDS[2, 2] = 0;
                btn9.BackgroundImage = Properties.Resources.kk;
            }
            else
            {
                puzzleIDS[2, 2] = Convert.ToInt16(btn9.Text);
                btn9.BackgroundImage = Properties.Resources._9;
            }

            int hn = Hn(puzzleIDS);
            Pqueue.Enqueue(puzzleIDS, null, null,hn);
        }

        //*****************************************************
        public bool Goal(Int16[,] puzzleArray)
        {
            i++;
            if (puzzleArray[0, 0] == 1 &&
                     puzzleArray[0, 1] == 2 &&
                     puzzleArray[0, 2] == 3 &&
                     puzzleArray[1, 0] == 4 &&
                     puzzleArray[1, 1] == 5 &&
                     puzzleArray[1, 2] == 6 &&
                     puzzleArray[2, 0] == 7 &&
                     puzzleArray[2, 1] == 8 &&
                     puzzleArray[2, 2] == 0)
            {
                return true;
            }

            return false;

        }

        //*****************************************************

        public NodeAStar AstarSearch()
        {
            NodeAStar pz;
            pz = Pqueue.Peek();
            while (Goal(pz.PuzzleCLASS) == false)
            {
                addNode(pz);
                pz = Pqueue.Dequeue();

            }

            return pz;

        }

        //*****************************************************

        public void addNode(NodeAStar puzzle)
        {
            int hn;
            string id = SearchArray((Int16[,])puzzle.PuzzleCLASS);
            Int16 temp;
            switch (id)
            {
                case "00":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 0];
                        pz1[1, 0] = pz1[0, 0];
                        pz1[0, 0] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Down", puzzle, hn);
                        }
                        RemoveVisited(puzzle);



                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[0, 1];
                        pz1[0, 1] = pz1[0, 0];
                        pz1[0, 0] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Right", puzzle, hn);
                        }
                        

                        break;
                    }
                case "01":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 1];
                        pz1[1, 1] = pz1[0, 1];
                        pz1[0, 1] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Down", puzzle, hn);
                        }
                        RemoveVisited(puzzle);

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[0, 0];
                        pz1[0, 0] = pz1[0, 1];
                        pz1[0, 1] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Left", puzzle, hn);
                        }
                        

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[0, 2];
                        pz1[0, 2] = pz1[0, 1];
                        pz1[0, 1] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Right", puzzle, hn);
                        }
                        

                        break;
                    }
                case "02":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 2];
                        pz1[1, 2] = pz1[0, 2];
                        pz1[0, 2] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Down", puzzle, hn);
                        }
                        RemoveVisited(puzzle);

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[0, 1];
                        pz1[0, 1] = pz1[0, 2];
                        pz1[0, 2] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Left", puzzle, hn);
                        }
                        

                        break;
                    }
                case "10":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle); 
                        temp = pz1[2, 0];
                        pz1[2, 0] = pz1[1, 0];
                        pz1[1, 0] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Down", puzzle, hn);
                        }
                        RemoveVisited(puzzle);


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[0, 0];
                        pz1[0, 0] = pz1[1, 0];
                        pz1[1, 0] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Up", puzzle, hn);
                        }
                        


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 1];
                        pz1[1, 1] = pz1[1, 0];
                        pz1[1, 0] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Right", puzzle, hn);
                        }
                        

                        break;
                    }
                case "11":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[2, 1];
                        pz1[2, 1] = pz1[1, 1];
                        pz1[1, 1] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Down", puzzle, hn);
                        }
                        RemoveVisited(puzzle);

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[0, 1];
                        pz1[0, 1] = pz1[1, 1];
                        pz1[1, 1] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Up", puzzle, hn);
                        }
                        


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 0];
                        pz1[1, 0] = pz1[1, 1];
                        pz1[1, 1] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Left", puzzle, hn);
                        }
                        

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 2];
                        pz1[1, 2] = pz1[1, 1];
                        pz1[1, 1] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Right", puzzle, hn);
                        }
                        



                        break;
                    }
                case "12":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[2, 2];
                        pz1[2, 2] = pz1[1, 2];
                        pz1[1, 2] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Down", puzzle, hn);
                        }
                        RemoveVisited(puzzle);

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[0, 2];
                        pz1[0, 2] = pz1[1, 2];
                        pz1[1, 2] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Up", puzzle, hn);
                        }
                        


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 1];
                        pz1[1, 1] = pz1[1, 2];
                        pz1[1, 2] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Left", puzzle, hn);
                        }
                        

                        break;
                    }
                case "20":
                    {

                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 0];
                        pz1[1, 0] = pz1[2, 0];
                        pz1[2, 0] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Up", puzzle, hn);
                        }
                        RemoveVisited(puzzle);

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[2, 1];
                        pz1[2, 1] = pz1[2, 0];
                        pz1[2, 0] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Right", puzzle, hn);
                        }
                        


                        break;
                    }
                case "21":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 1];
                        pz1[1, 1] = pz1[2, 1];
                        pz1[2, 1] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Up", puzzle, hn);
                        }
                        RemoveVisited(puzzle);


                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[2, 0];
                        pz1[2, 0] = pz1[2, 1];
                        pz1[2, 1] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Left", puzzle, hn);

                        }
                       

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[2, 2];
                        pz1[2, 2] = pz1[2, 1];
                        pz1[2, 1] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Right", puzzle, hn);

                        }
                        

                        break;
                    }
                case "22":
                    {
                        Int16[,] pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[1, 2];
                        pz1[1, 2] = pz1[2, 2];
                        pz1[2, 2] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Up", puzzle, hn);

                        }
                        RemoveVisited(puzzle);

                        pz1 = new Int16[3, 3];
                        pz1 = Clone(pz1, puzzle);
                        temp = pz1[2, 1];
                        pz1[2, 1] = pz1[2, 2];
                        pz1[2, 2] = temp;
                        if (SimilarFinder(pz1))
                        {
                            hn = Hn(pz1);
                            Pqueue.Enqueue(pz1, "Left", puzzle, hn);

                        }
                        

                        break;
                    }
            }
        }

        //*****************************************************

        private Int16[,] Clone(Int16[,] pz1, NodeAStar puzzle)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pz1[i, j] = puzzle.PuzzleCLASS[i, j];
                }
            }
            return pz1;
        }

        //*****************************************************

        public string SearchArray(Int16[,] puzzleSearch)
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (puzzleSearch[i, j] == 0)
                        return i.ToString() + j.ToString();
                }
            }
            return "";
        }

        //*****************************************************

        public List<string> PathFinder(NodeAStar node)
        {
            while (node.PARENT != null)
            {
                PathList.Add(node.ActionCLASS);
                NodeNumber.Add(node.NodeNUMBER);
                node = node.PARENT;
                j++;
            }

            return PathList;
        }

        //*****************************************************
        public int DepthFinder()
        {
            return j;
        }

        //*****************************************************

        int Hn(Int16[,] pzl)
        {
            int hn = 0;

            for (int i = 1; i < 9; i++)
            {
                switch(i)
                {
                   
                    case 1:
                        {
                            
                            if (pzl[0, 1] == 1)
                                hn += 1;
                            else if (pzl[0, 2] == 1)
                                hn += 2;
                            else if (pzl[1, 0] == 1)
                                hn += 1;
                            else if (pzl[1, 1] == 1)
                                hn += 2;
                            else if (pzl[1, 2] == 1)
                                hn += 3;
                            else if (pzl[2, 0] == 1)
                                hn += 2;
                            else if (pzl[2, 1] == 1)
                                hn += 3;
                            else if (pzl[2, 2] == 1)
                                hn += 4;

                            break;
                        }
                    case 2:
                        {
                            if (pzl[0, 0] == 2)
                                hn += 1;
                            else if (pzl[0, 2] == 2)
                                hn += 1;
                            else if (pzl[1, 0] == 2)
                                hn += 2;
                            else if (pzl[1, 1] == 2)
                                hn += 1;
                            else if (pzl[1, 2] == 2)
                                hn += 2;
                            else if (pzl[2, 0] == 2)
                                hn += 3;
                            else if (pzl[2, 1] == 2)
                                hn += 2;
                            else if (pzl[2, 2] == 2)
                                hn += 3;

                            break;
                        }
                    case 3:
                        {
                            if (pzl[0, 0] == 3)
                                hn += 2;
                            else if (pzl[0, 1] == 3)
                                hn += 1;
                            else if (pzl[1, 0] == 3)
                                hn += 3;
                            else if (pzl[1, 1] == 3)
                                hn += 2;
                            else if (pzl[1, 2] == 3)
                                hn += 1;
                            else if (pzl[2, 0] == 3)
                                hn += 4;
                            else if (pzl[2, 1] == 3)
                                hn += 3;
                            else if (pzl[2, 2] == 3)
                                hn += 2;

                            break;
                        }
                    case 4:
                        {
                            if (pzl[0, 0] == 4)
                                hn += 1;
                            else if (pzl[0, 1] == 4)
                                hn += 2;
                            else if (pzl[0, 2] == 4)
                                hn += 3;
                            else if (pzl[1, 1] == 4)
                                hn += 1;
                            else if (pzl[1, 2] == 4)
                                hn += 2;
                            else if (pzl[2, 0] == 4)
                                hn += 1;
                            else if (pzl[2, 1] == 4)
                                hn += 2;
                            else if (pzl[2, 2] == 4)
                                hn += 3;

                            break;
                        }
                    case 5:
                        {
                            if (pzl[0, 0] == 5)
                                hn += 2;
                            else if (pzl[0, 1] == 5)
                                hn += 1;
                            else if (pzl[0, 2] == 5)
                                hn += 2;
                            else if (pzl[1, 0] == 5)
                                hn += 1;
                            else if (pzl[1, 2] == 5)
                                hn += 1;
                            else if (pzl[2, 0] == 5)
                                hn += 2;
                            else if (pzl[2, 1] == 5)
                                hn += 1;
                            else if (pzl[2, 2] == 5)
                                hn += 2;

                            break;
                        }
                    case 6:
                        {
                            if (pzl[0, 0] == 6)
                                hn += 3;
                            else if (pzl[0, 1] == 6)
                                hn += 2;
                            else if (pzl[0, 2] == 6)
                                hn += 1;
                            else if (pzl[1, 0] == 6)
                                hn += 2;
                            else if (pzl[1, 1] == 6)
                                hn += 1;
                            else if (pzl[2, 0] == 6)
                                hn += 3;
                            else if (pzl[2, 1] == 6)
                                hn += 2;
                            else if (pzl[2, 2] == 6)
                                hn += 1;

                            break;
                        }
                    case 7:
                        {
                            if (pzl[0, 0] == 7)
                                hn += 2;
                            else if (pzl[0, 1] == 7)
                                hn += 3;
                            else if (pzl[0, 2] == 7)
                                hn += 4;
                            else if (pzl[1, 0] == 7)
                                hn += 1;
                            else if (pzl[1, 1] == 7)
                                hn += 2;
                            else if (pzl[1, 2] == 7)
                                hn += 3;
                            else if (pzl[2, 1] == 7)
                                hn += 1;
                            else if (pzl[2, 2] == 7)
                                hn += 2;

                            break;
                        }
                    case 8:
                        {
                            if (pzl[0, 0] == 8)
                                hn += 3;
                            else if (pzl[0, 1] == 8)
                                hn += 2;
                            else if (pzl[0, 2] == 8)
                                hn += 3;
                            else if (pzl[1, 0] == 8)
                                hn += 2;
                            else if (pzl[1, 1] == 8)
                                hn += 1;
                            else if (pzl[1, 2] == 8)
                                hn += 2;
                            else if (pzl[2, 0] == 8)
                                hn += 1;
                            else if (pzl[2, 2] == 8)
                                hn += 1;

                            break;
                        }
                }
            }

            return hn;
        }

        //*****************************************************
        void RemoveVisited(NodeAStar Visited)
        {
            if (Visited.BACK == null && Visited.NEXT == null)
            {

            }
            else if (Visited.BACK == null && Visited.NEXT != null)
            {
                Pqueue.Front = Visited.NEXT;
                Visited.NEXT.BACK = null;
                Visited.BACK = Visited.NEXT = null;
            }
            else if (Visited.NEXT == null)
            {
                Pqueue.Rear = Visited.BACK;
                Visited.BACK.NEXT = null;
                Visited.BACK = Visited.NEXT = null;
            }
            else
            {
                Visited.BACK.NEXT = Visited.NEXT;
                Visited.NEXT.BACK = Visited.BACK;
                Visited.BACK = Visited.NEXT = null;
            }
            
        }

        //*****************************************************
        bool SimilarFinder(Int16[,] pzl)
        {

            NodeAStar current = Pqueue.Front;
            while (current != null)
            {
                if (SimilarArray(pzl,current.PuzzleCLASS))
                {
                    return false;
                }
                current = current.NEXT;
            }
            return true;
        }

        //*****************************************************
        bool SimilarArray(Int16[,] pz1,Int16[,] pz2)
        {
            int Count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (pz1[i, j] == pz2[i, j])
                        Count++;
                }
            }

            if (Count == 9)
                return true;

            return false;
        }
    }
}
