safeReplace();
function safeReplace() {
    const logo = document.querySelector(".topbar-wrapper a.link");
    try {
        if (!logo) {
            setTimeout(safeReplace, 500);
            return;
        } else {
            logo.innerHTML = "<img src='/SwaggerCustom/portfoliologo.png' alt='logo'/>";
        }
    } catch {
        console.log("catch");
    }

};