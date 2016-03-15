# Legacy Code Kata 2

Refer to the [readme.md](README.md) for an overview of the kata series and the code base we're working on.

## Learning aims

1. Practise restraint in making changes: make the codebase safe before starting work on it. 
2. Practise techniques for writing descriptive tests against legacy code to capture the system's behaviour. 
3. Using tests as a form of executable specification for a system.

## Tasks

Provide complete code coverage over the app. You could use NCrunch/DotCover to measure this. How else might you achieve this?

1. **Write a Golden Master test** to capture the current behaviour of the whole app. You can make safe, additive changes to the system to help you to do this (e.g. by adding console output).

2. **Write characterisation tests** to capture the remaining behaviour of lower level and edge case parts of the system, e.g. per feature.

Try to keep your tests DRY through relentless refactoring: aim for highly descriptive tests by removing duplication everywhere you see it. These tests will allow us to make changes to the production code while maintaining confidence that the whole system still functions as it should, e.g. after refactorings or implementing new features such as conjured items.

## FAQ

### What is a Golden Master test?

A Golden Master test captures the output of the entire system. This lets you compare future output of the system against the saved "golden master" to discover unexpected changes.

See http://blog.codeclimate.com/blog/2014/02/20/gold-master-testing/

See also [this interesting design tip](http://blog.thecodewhisperer.com/permalink/how-not-to-write-golden-master-tests). 

### What is a characterisation test?

Characterisation tests describe the actual behavior of an existing piece of software. They protect the existing behavior of legacy code against unintended changes via automated testing. They provide a safety net for extending and refactoring code that does not have adequate unit tests. Note that a golden master test is a type of characterisation test.

See https://en.wikipedia.org/wiki/Characterization_test
