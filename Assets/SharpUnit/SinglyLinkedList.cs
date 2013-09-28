using System;

namespace SinglyLinkedListExample { 
	
	public class SingleLinkNode<T>
	{ 
		public T data;
		public SingleLinkNode<T> link;
		public SingleLinkNode(T init) 
		{ 
			data = init;
			link = null;
		}
	} 
	
	
	public class SinglyLinkedList<T>
	{ 
		SingleLinkNode<T> head;
		SingleLinkNode<T> current;
	
		public SinglyLinkedList(T[] a) 
		{ 
			for (int i=0; i<a.Length; i++)
			{ 
				Append(a[i]);
			}
		}
	
		public void Append(T o) 
		{
			if (head == null) 
			{ 
				head = new SingleLinkNode<T>(o);
			}
			else 
			{
				SingleLinkNode<T> newNode = new SingleLinkNode<T>(o);
				
				current = head; 
				while (current.link != null)
				{
					current = current.link;
				}
				current.link = newNode;
			}
		}
	
		public SingleLinkNode<T> GetNthLast(int n) 
		{
			/*
			 * the 0th last item doesn't strictly exist
			 * since the 1st last item is the last
			 * ...couldn't bring myself to preempt the meaning of 0 here and set n to 1
			 */
			if ( n <= 0 ) 
			{ 
				return default(SingleLinkNode<T>);
			}
			
			SingleLinkNode<T> returned = head;
			current = head;
			
			for (int i=1; i<n; i++)
			{ 
			
				if (current != null) 
				{ 
					current = current.link;
				} 
				else 
				{ 
					return default(SingleLinkNode<T>);
				}
			}
			
			while ( (current.link != null) )  
			{ 
				current = current.link;
				returned = returned.link;
			} 
			
			if (returned == null) 
			{				
				return default(SingleLinkNode<T>);
			} 
			else
			{ 
				return returned;
			}
		}
	}
}

