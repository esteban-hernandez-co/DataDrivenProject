using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class QuestionnaireLinkedList
    {
        Node head; //head of list

        public Node Head { get => head; set => head = value; }

        /* Linked list Node. This inner class is made static so that
        main() can access it */

        public void InsertLast(QuestionnaireLinkedList linkedList, int questionNumber, QuestionDTO question)
        {
            Node newNode = new Node(questionNumber, question);
            if (linkedList.Head == null)
            {
                newNode.Previous = null;
                linkedList.Head = newNode;
                return;
            }
            Node lastNode = GetLastNode(linkedList);
            lastNode.Next = newNode;
            newNode.Previous = lastNode;
        }
        public Node GetLastNode(QuestionnaireLinkedList linkedList)
        {
            Node temp = linkedList.Head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            return temp;
        }
        public void InsertAfter(Node prev_node, int questionNumber, QuestionDTO question)
        {
            if (prev_node == null)
            {
                Console.WriteLine("The given prevoius node cannot be null");
                return;
            }
            Node newNode = new Node(questionNumber, question);
            newNode.Next = prev_node.Next;
            prev_node.Next = newNode;
            newNode.Previous = prev_node;
            if (newNode.Next != null)
            {
                newNode.Next.Previous = newNode;
            }
        }

        // This function prints contents of
        // linked list starting from the
        // given node
        public void printList()
        {
            Node tnode = head;
            while (tnode != null)
            {
                Console.Write("Question#" + tnode.QuestionNumber + " ");
                Console.Write("\n" + tnode.CurrentQuestion.ToString() + " ");
                Console.Write("\nNext Question" + tnode.Next.CurrentQuestion.ToString() + " ");
                
                tnode = tnode.Next;
            }
        }
        public Node FindNodebyQuestionId(QuestionnaireLinkedList linkedList, int key)
        {
            Node temp = linkedList.head;
            if (temp != null && temp.CurrentQuestion.QuestionId == key)
            {
                return temp;
            }
            while (temp != null && temp.CurrentQuestion.QuestionId != key)
            {
                temp = temp.Next;
            }
            if (temp == null)
            {
                return null;
            }
            return temp;
        }
        public void DeleteNodebyQuestionId(QuestionnaireLinkedList linkedList, int key)
        {
            Node temp = linkedList.head;
            if (temp != null && temp.CurrentQuestion.QuestionId == key)
            {
                linkedList.head = temp.Next;
                linkedList.head.Previous = null;
                return;
            }
            while (temp != null && temp.CurrentQuestion.QuestionId != key)
            {
                temp = temp.Next;
            }
            if (temp == null)
            {
                return;
            }
            if (temp.Next != null)
            {
                temp.Next.Previous = temp.Previous;
            }
            if (temp.Previous != null)
            {
                temp.Previous.Next = temp.Next;
            }
        }

    }
    public class Node
    {
        int questionNumber;
        Node previous;
        QuestionDTO currentQuestion;
        Node next;
        public Node(int questionN, QuestionDTO question)
        {
            questionNumber = questionN;
            currentQuestion = question;
            previous = null;
            next = null;
        } // Constructor

        public int QuestionNumber { get => questionNumber; set => questionNumber = value; }
        public QuestionDTO CurrentQuestion { get => currentQuestion; set => currentQuestion = value; }
        public Node Next { get => next; set => next = value; }
        
        public Node Previous { get => previous; set => previous = value; }
        
    }
    
}
