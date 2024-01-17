# NeuralNetwork
A neural network class library in .NET 8, along with a simple console app to manually test it's ability to learn through forward and backpropagation.

*** NOTE: This is not a finished product and is very much in the development stages.
Much refactoring and further development is still required for the Console App (especially /Experiments and /NeuralNetworkCreationPlans)
You can find some planned future improvements / bugs noted in the /Notes folder in each project.

In order to run an Experiment, e.g. Experiment_FA_1, you must set the Console App as the startup project.
You should also set your download path for any downloads involved in the experiment, within the config.json file:
![image](https://github.com/leojgrant/NeuralNetwork/assets/66557864/5a5377d0-4cc9-41a9-9a5b-5133603a2f04)

You can then select it in the application:
![image](https://github.com/leojgrant/NeuralNetwork/assets/66557864/f268cdf2-a6b1-43c3-a5d4-b5a7be63561a)


## NeuralNetwork.Service

The neural network service offers a modular and extendable library for constructing a custom neural network with a high degree of control.
- The Neural Network Service is currently the cleanest code in the repo.
- Tests still need adding.

## NeuralNetwork.ConsoleApp

The neural network console app is designed with ecperimentation in mind by allowing for rapid construction of experiments
- The current /Experiments dir is where you can mess around with personalised experiments.
- The /NeuralNetworkCreationPlans dir is where you can create UX / UI flows for neural network creation within your Experiment (e.g. you can use a pre-configured neural network, or you can customise it on the fly within the app - it all depends on the creation plan used in the Experiment).

An example Experiment I have run is shown below:
![image](https://github.com/leojgrant/NeuralNetwork/assets/66557864/e2383983-78b2-43fd-9ce6-a3cfa8905112)

 This outputs the following graph:
![image](https://github.com/leojgrant/NeuralNetwork/assets/66557864/bfd9854c-af54-4d66-9a25-15dfb8178b8c)

It is important to remember to add the Experiment name or NeuralNetworkCreationPlan to the config file when you create one.

## Theory

The theory underlying the neural network service will be described below.
