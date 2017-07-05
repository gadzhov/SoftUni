class Startup
{
    static void Main(string[] args)
    {
        var dog = new Dog();
        dog.Eat();
        dog.Bark();

        var puppy = new Puppy();
        puppy.Eat();
        puppy.Bark();
        puppy.Weep();

        var cat = new Cat();
        cat.Eat();
        cat.Meow();
    }
}
