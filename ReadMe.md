# Ollama Setup Guide

This guide will walk you through the process of installing, configuring, and using Ollama on Windows. Follow the steps carefully to ensure a smooth setup.

---

## Prerequisites
1. A Windows computer.
2. Internet connection for downloading and pulling models.
3. Basic familiarity with using the command line.

---

## Step 1: Download and Install Ollama

1. **Download Ollama**  
   Visit the [Ollama GitHub page](https://github.com/ollama/ollama) to download the installer for Windows.

2. **Install Ollama**
   Run the downloaded installer and follow the on-screen instructions to complete the installation process.

---

## Step 2: Verify Installation

1. Open a terminal window (e.g., Command Prompt or PowerShell).
2. Run the following command to check if Ollama is installed correctly:  
   ```bash
   ollama
   ```
   - If installed successfully, you will see a list of available commands displayed.
   - If the command is not recognized, ensure that Ollama is added to your system's PATH or try reinstalling.

---

## Step 3: Start Ollama

1. Start the Ollama server by running:  
   ```bash
   ollama serve
   ```
   - If the server starts successfully, it will bind to `127.0.0.1:11434`.

2. **Troubleshooting the Port Error:**  
   If you encounter the following error:  
   ```
   Error: listen tcp 127.0.0.1:11434: bind: Only one usage of each socket address (protocol/network address/port) is normally permitted.
   ```
   Do not worry! This indicates that the Ollama server is already running in the background. You can verify it by navigating to:  
   [http://localhost:11434/](http://localhost:11434/)  
   If Ollama is running, you will see the message:  
   `"Ollama is running"`

---

## Step 4: Pull the Llama3.1 Model

1. In the terminal, run the following command to download the Llama3.1 model:  
   ```bash
   ollama pull Llama3.1
   ```
   - This command will fetch the Llama3.1 model from the server.
   - **Note:** The download might take some time depending on your internet speed. Feel free to grab a coffee while you wait.

2. Once the download is complete, you are ready to start using the API.

---

## Additional Tips

- **Stopping the Server:** To stop the server, press `Ctrl+C` in the terminal where it is running.
- **Help Commands:** To explore all available commands, you can run:  
  ```bash
  ollama help
  ```
- **Model Management:** You can pull additional models or manage existing ones using `ollama pull <model_name>` or other relevant commands.