
using sessionizer.Models;

namespace sessionizer.Loaders;

public interface ILoader <out T> 
{
    T LoadData(List<TableRecord> records);
}

//file reader - getting from config file all the paths and have method to return the array of the lines by generic class.
//loader - interface for all the loaders and the aim of this class to load the data to data strucatre. // will get by param the data 
//implent loader for each data stracture that i want to initiliize.
//data starcture - this class holds all the data after the loading.
//handler - implement the logic of each different request.
//boostrap - initilize the file reader, the the loaders ( initlizae )
//in the conotrloor we will have member of every handler.