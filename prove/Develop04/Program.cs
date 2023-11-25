#include <iostream>
#include <chrono>
#include <thread>
#include <vector>
#include <cstdlib>

void showSpinner(int seconds) {
    for (int i = 0; i < seconds; ++i) {
        std::this_thread::sleep_for(std::chrono::seconds(1));

        // Display a simple spinner animation
        const char spinner[] = {'|', '/', '-', '\\'};
        std::cout << "\r" << spinner[i % 4] << " ";
        std::cout.flush();
    }
    std::cout << std::endl;
}

void startActivity(const std::string& activityName, const std::string& description, int& duration) {
    std::cout << "Welcome to " << activityName << "!" << std::endl;
    std::cout << description << std::endl;
    std::cout << "Enter the duration in seconds: ";
    std::cin >> duration;

    std::cout << "Get ready to begin..." << std::endl;
    showSpinner(3); // Pause for 3 seconds before starting
}

void endActivity(const std::string& activityName, int duration) {
    showSpinner(3); // Pause for 3 seconds before finishing
    std::cout << "Great job! You've completed the " << activityName << " for " << duration << " seconds." << std::endl;
}

void breathingActivity() {
    int duration;
    startActivity("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", duration);

    while (duration > 0) {
        std::cout << "Breathe in..." << std::endl;
        showSpinner(3);
        duration -= 3;

        if (duration <= 0) break;

        std::cout << "Breathe out..." << std::endl;
        showSpinner(3);
        duration -= 3;
    }

    endActivity("Breathing Activity", duration);
}

void reflectionActivity() {
    int duration;
    startActivity("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", duration);

    // List of prompts and questions
    std::vector<std::string> prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    std::vector<std::string> questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
        // Add more questions as needed
    };

    while (duration > 0) {
        // Display a random prompt
        int randomIndex = rand() % prompts.size();
        std::cout << prompts[randomIndex] << std::endl;
        showSpinner(3);
        duration -= 3;

        // Ask random questions
        for (const auto& question : questions) {
            std::cout << question << std::endl;
            showSpinner(3);
            duration -= 3;

            if (duration <= 0) break;
        }
    }

    endActivity("Reflection Activity", duration);
}

void listingActivity() {
    int duration;
    startActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", duration);

    // List of prompts
    std::vector<std::string> prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
        // Add more prompts as needed
    };

    // Display a random prompt
    int randomIndex = rand() % prompts.size();
    std::cout << prompts[randomIndex] << std::endl;
    showSpinner(3);

    std::cout << "Start listing items..." << std::endl;
    showSpinner(duration);

    // User lists items (simulate by waiting for the specified duration)
    showSpinner(3); // Pause for 3 seconds before displaying the number of items entered
    std::cout << "You listed 10 items." << std::endl;

    endActivity("Listing Activity", duration);
}

int main() {
    srand(static_cast<unsigned>(time(nullptr)));

    while (true) {
        std::cout << "Menu:" << std::endl;
        std::cout << "1. Breathing Activity" << std::endl;
        std::cout << "2. Reflection Activity" << std::endl;
        std::cout << "3. Listing Activity" << std::endl;
        std::cout << "4. Quit" << std::endl;

        int choice;
        std::cout << "Enter your choice: ";
        std::cin >> choice;

        switch (choice) {
            case 1:
                breathingActivity();
                break;
            case 2:
                reflectionActivity();
                break;
            case 3:
                listingActivity();
                break;
            case 4:
                std::cout << "Goodbye!" << std::endl;
                return 0;
            default:
                std::cout << "Invalid choice. Please try again." << std::endl;
        }
    }

    return 0;
}