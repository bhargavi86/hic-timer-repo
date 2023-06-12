const PROXY_CONFIG = [
  {
    context: [
      "/api/Inventory",
    ],
    target: "https://localhost:7119",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
