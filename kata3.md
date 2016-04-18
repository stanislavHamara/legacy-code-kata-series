# Legacy Code Kata 3

Refer to the [readme.md](README.md) for an overview of the kata series and the code base we're working on.

## Learning objectives

Experiment with techniques for refactoring legacy code.

## Tasks

1. Think about what you would want `UpdateQuality` to look like, if you had unlimited time.
2. Refactor the `UpdateQuality` method, taking it in the direction you decided on in step 1. You don't have unlimited time, so be sure to take small steps, each of which should improve the code while taking it in the right direction.

Don't forget to run the characterisation tests after each change. NCrunch, or a similar tool, could be useful here.

## Recommended techniques

* Extract variables/fields to hide complexity and reduce duplication
* If you are finding it hard to reason about a conditional then trying extract a method for the condition
* Check names of methods/variables with your pair partner before committing
* Check the diff before committing, after you extract methods you can re-inline them to make sure you haven't changed behaviour
* Try other refactorings like invert-if where appropriate to simplify the code
