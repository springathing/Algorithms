using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public class StackQueue
    {
        
    }

    internal class LinkListStack
    {
        Node top;

        public LinkListStack()
        {
            this.top = null;
        }

        internal void Push(int value)
        {
            Node newNode = new Node(value);
            if (top == null)
            {
                newNode.next = null;
            }
            else
            {
                newNode.next = top;
            }
            top = newNode;
            Console.WriteLine("{0} pushed to stack", value);
        }

        internal void Pop()
        {
            if (top == null)
            {
                Console.WriteLine("Stack Underflow. Deletion not possible");
                return;
            }

            Console.WriteLine("Item popped is {0}", top.data);
            top = top.next;
        }

        internal void Peek()
        {
            if (top == null)
            {
                Console.WriteLine("Stack Underflow.");
                return;
            }

            Console.WriteLine("{0} is on the top of Stack", this.top.data);
        }
    }

    internal class LinkListQueue
    {
        Node front;
        Node rear;

        public LinkListQueue()
        {
            this.front = this.rear = null;
        }

        internal void Enqueue(int item)
        {
            Node newNode = new Node(item);

            // If queue is empty, then new node is front and rear both  
            if (this.rear == null)
            {
                this.front = this.rear = newNode;
            }
            else
            {
                // Add the new node at the end of queue and change rear  
                this.rear.next = newNode;
                this.rear = newNode;
            }
            Console.WriteLine("{0} inserted into Queue", item);
        }

        internal void Dequeue()
        {
            // If queue is empty, return NULL.  
            if (this.front == null)
            {
                Console.WriteLine("The Queue is empty");
                return;
            }

            // Store previous front and move front one node ahead  
            Node temp = this.front;
            this.front = this.front.next;

            // If front becomes NULL, then change rear also as NULL  
            if (this.front == null)
            {
                this.rear = null;
            }

            Console.WriteLine("Item deleted is {0}", temp.data);
        }
    }
}
