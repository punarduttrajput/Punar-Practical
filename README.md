# 🚀 Project Setup Instructions

## 💻 Prerequisites

- Visual Studio (2019/2022 recommended) with .NET support
- Node.js (version 18 or above recommended)
- Angular CLI installed globally  
  ```bash
  npm install -g @angular/cli
  ```

---

## 🧑‍💻 Clone the repository

```bash
git clone <your-repo-url>
cd <your-repo-folder>
```

---

## ⚙️ Backend Setup (Web API)

1️⃣ Open the `WebApi` solution file (`.sln`) in Visual Studio.

2️⃣ Build the solution.

3️⃣ Run the Web API project.

4️⃣ Once running, check the **base URL** (e.g., `https://localhost:5001` or `http://localhost:5000`) in the browser or Visual Studio console.

---

## 🔧 Update Angular Service

1️⃣ Open the Angular frontend project (inside `AngFrontend` folder).

2️⃣ Locate your service file (e.g., `observation.service.ts`).

3️⃣ Update the API base URL to match the backend endpoint. Example:

```ts
private baseUrl = 'https://localhost:5001/api/observations';
```

---

## 🌐 Frontend Setup (Angular)

1️⃣ Navigate to the Angular project folder:

```bash
cd AngFrontend
```

2️⃣ Install dependencies:

```bash
npm install
```

3️⃣ Run the Angular app:

```bash
ng serve
```

4️⃣ Open your browser and navigate to:

```
http://localhost:4200
```

---

## ✅ Project Structure

```
root
├── WebApi
│   └── ... (API code)
├── AngFrontend
│   └── ... (Angular code)
├── README.md
└── ...
```

---

## 💬 Notes

- Make sure the backend is running before starting the Angular app.
- If your backend runs on a different port, update it in the service file before running the frontend.
- You might need to allow CORS in your Web API if accessing from different origins.

---

## 🎉 You’re all set! Enjoy 🚀
