/*
 * ListTest.cs
 * Author: 	Matthew Lenton
 * Email: 	matthew.lenton@gmail.com
 * Date: 	September 2013
 */

using System;
using SharpUnit;
using SinglyLinkedListExample;

namespace ListUnitTest 
{ 
	public class ListTest : TestCase 
	{
		/** declarations for the test subjects */
		SinglyLinkedList<int> testList1;
		SinglyLinkedList<int> testList2;
		SinglyLinkedList<int> testList3;
		SinglyLinkedList<int> testList4;		
		SinglyLinkedList<int> testList5;
			 
		/** Setup test resources, called before each test. */
	    public override void SetUp() 
		{
			
			/** an array of positive integers */
			testList1 = new SinglyLinkedList<int>(new int[] {0,1,2,3,4,5,6,7,8,9});

			/** an array containing negative integers */
			testList2 = new SinglyLinkedList<int>(new int[] {-24, 42, 8, 0, 1, -5});

			/** an array of length 5, also containing negative integers */
			testList3 = new SinglyLinkedList<int>(new int[] {-1,-2,-3,-4,-5});

			/** an array of length zero */
			testList4 = new SinglyLinkedList<int>(new int[] {});

			/** an array containing less than 5 integers */
			testList5 = new SinglyLinkedList<int>(new int[] {1,2,3});

			/* todo: ensure using new int[] in cstr parameter in this way does not cause memory leak 
			 * done as such for brevity & readability, for the purposes of this exercise 
			 */
		}
	
	    /** Dispose of test resources, called after each test */
	    public override void TearDown() 
		{
			testList1 = null;
			testList2 = null;
			testList3 = null;
			testList4 = null;
			testList5 = null;
	    }
	
		/** test the 'fifth-last' cases for each of the test lists */
	    [UnitTest]
	    public void TestList1_5thLast() 
		{
			/** ensure the correct value is returned */
			Assert.Equal( 5, testList1.GetNthLast(5).data );
		}
		
	    [UnitTest]
	    public void TestList2_5thLast() 
		{
			/** ensure the correct value is returned */
			Assert.Equal( 42, testList2.GetNthLast(5).data );
		}
		
	    [UnitTest]
	    public void TestList3_5thLast() 
		{
			/** ensure the correct value is returned */
			Assert.Equal( -1, testList3.GetNthLast(5).data );
		}
		
	    [UnitTest]
	    public void TestList4_5thLast() 
		{
			/** ensure it won't cause a runtime error */
			Assert.Null( testList4.GetNthLast(5) );
		}
		
	    [UnitTest]
	    public void TestList5_5thLast() 
		{
			/** ensure it won't cause a runtime error */
			Assert.Null( testList5.GetNthLast(5) );
		}

		/** fully test one of the arrays */
	    [UnitTest]
	    public void TestList1_NthLast() 
		{
			int l = testList1.Count();
			for (int i=0; i<l; i++)
			{
				Assert.Equal( i, testList1.GetNthLast(l-i).data );
			}
		}
		
		/*
		 * Test edge cases and out-of bounds 
		 */
	    [UnitTest]
	    public void TestList1EdgeCases() 
		{
			Assert.Equal( 0, testList1.GetNthLast(10).data );
			Assert.Equal( 9, testList1.GetNthLast(1).data );
			Assert.Null( testList1.GetNthLast(11) );
			Assert.Null( testList1.GetNthLast(0) );
			Assert.Null( testList1.GetNthLast(-1) );
		}
	    public void TestList2EdgeCases() 
		{
			Assert.Equal( 24, testList2.GetNthLast(6).data );
			Assert.Equal( -5, testList2.GetNthLast(1).data );
			Assert.Null( testList2.GetNthLast(7) );
			Assert.Null( testList2.GetNthLast(0) );
			Assert.Null( testList2.GetNthLast(-1) );
		}
	    public void TestList3EdgeCases() 
		{
			Assert.Equal( -1, testList3.GetNthLast(5).data );
			Assert.Equal( -5, testList3.GetNthLast(1).data );
			Assert.Null( testList3.GetNthLast(0) );
			Assert.Null( testList3.GetNthLast(-1) );
		}
	    public void TestList4EdgeCases() 
		{
			Assert.Null( testList4.GetNthLast(1) );
			Assert.Null( testList4.GetNthLast(0) );
			Assert.Null( testList4.GetNthLast(-1) );
		}
	    public void TestList5EdgeCases() 
		{
			Assert.Equal( 0, testList5.GetNthLast(3).data );
			Assert.Equal( 3, testList5.GetNthLast(1).data );
			Assert.Null( testList5.GetNthLast(4) );
			Assert.Null( testList5.GetNthLast(0) );
			Assert.Null( testList5.GetNthLast(-1) );
		}
		
		
		/* 
		 * test negative integers passed to the function don't cause runtime error
		 */
	    public void TestNegativeNth() 
		{
			Assert.Null( testList2.GetNthLast(-100) );

		}

	
	}
}


