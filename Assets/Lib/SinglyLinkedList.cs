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
		public SinglyLinkedList() 
		{ 
			head = null;
			current = null;
		}	
		public SinglyLinkedList(T[] a) 
			: base()
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

		public int Count() 
		{
			int length = 0;
			if ( head != null ) 
			{ 
				current = head;
				length = 1;
				while (current.link != null) 
				{ 
					current = current.link;
					length++;
				}
			}
			return length;
		}
	
		/* 
		 * GetNthItem function
		 * Parameters: 			n
		 * Returns: 			nth last item in the list, where last item is n = 1
		 * Time complexity: 	O(n)
		 * Description: 		advances a scout n items in the list, then advances a finder along with scout until scout reaches the end of the list.
		 */
		public SingleLinkNode<T> GetNthLast(int n) 
		{
			if ( n <= 0 ) 
			{ 
				/*
				 * the 0th last item (and anything previous) doesn't strictly exist
				 * since the '1st last' item is the last ...couldn't bring myself to preempt the meaning of 0 here and set n to 1
				 */
				return default(SingleLinkNode<T>);
			}
			
			SingleLinkNode<T> finder = head;
			SingleLinkNode<T> scout = head;
			
			for (int i=1; i<n; i++)
			{ 
			
				if (scout != null) 
				{ 
					scout = scout.link;
				} 
				else 
				{ 
					return default(SingleLinkNode<T>);
				}
			}
			/** workaround NullPointerException when scout.Equals is called by the operator */
			try 
			{ 
				if ( scout == null ) 
				{ 
					return default(SingleLinkNode<T>);
				}

			} 
			catch (Exception e) 
			{
				Console.WriteLine(e);
				return default(SingleLinkNode<T>);
			}
			
			while ( (scout.link != null) )  
			{ 
				scout = scout.link;
				finder = finder.link;
			} 
			
			if (finder == null) 
			{				
				return default(SingleLinkNode<T>);
			} 
			else
			{ 
				return finder;
			}
		}
	}
}

