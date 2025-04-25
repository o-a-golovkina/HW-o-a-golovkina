#include <iostream>
#include <fstream>
#include <string>

using namespace std;

class FileManager {
private:
    ofstream file;
    string filePath;
    bool isOpen = false;

public:
    // Constructor that opens the file
    FileManager(const string& path)
        : filePath(path)
    {
        file.open(filePath, ios::out | ios::app); // open for writing, append to end
        if (file.is_open()) {
            isOpen = true;
            cout << "File opened successfully." << endl;
        }
        else {
            cout << "Failed to open the file." << endl;
        }
    }

    // Method for writing text to the file
    void WriteToFile(const string& text) {
        if (isOpen) {
            file << text << endl;
            cout << "Text written to the file successfully." << endl;
        }
    }

    // Destructor that automatically closes the file
    ~FileManager() {
        if (isOpen) {
            file.close();
            cout << "File closed and resources cleaned up." << endl;
        }
    }
};

int main() {
    string path = "test.txt";

    {
        FileManager fileManager(path);
        fileManager.WriteToFile("Hello, world!");
        // After leaving this block, the fileManager object will be destroyed, and the destructor will be called
    }

    cout << "Resources automatically released." << endl;

    return 0;
}
