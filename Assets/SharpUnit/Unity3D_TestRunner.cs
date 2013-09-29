/**
 * @file TestRunner.cs
 * 
 * Unity3D unit test runner.
 * Sets up the unit testing suite and executes all unit tests.
 * Drag this onto an empty GameObject to run tests.
 */

using UnityEngine;
using System.Collections;
using SharpUnit;
using Test_List_GetNthLast;

public class Unity3D_TestRunner : MonoBehaviour 
{
    /**
     * Initialize class resources.
     */
	void Start() 
    {
        // Create test suite
        TestSuite suite = new TestSuite();

        // Example: Add tests to suite
        suite.AddAll(new List_GetNthLast());

        // Run the tests
        TestResult res = suite.Run(null);

        // Report results
        Unity3D_TestReporter reporter = new Unity3D_TestReporter();
        reporter.LogResults(res);
	}
}
