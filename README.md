# Object-Pooling-in-Unity
Instantiate() and Destroy() are useful and necessary methods during gameplay. Each generally requires minimal CPU time.  However, for objects created during gameplay that have a short lifespan and get destroyed in vast numbers per second, the CPU needs to allocate considerably more time.
