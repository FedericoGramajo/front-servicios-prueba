function setCookie(name, value, seconds, path = "/") {
    if (!name || !value) {
        return;
    }
    let expires = "";
    if (seconds) {
        const date = new Date();
        date.setTime(date.getTime() + (seconds * 1000)); // Convert seconds to milliseconds
        expires = "; expires=" + date.toUTCString();
    }
    const cookieString = `${encodeURIComponent(name)}=${encodeURIComponent(value)}${expires}; path=${path}`;
    document.cookie = cookieString;
}
function getCookie(name) {
    const nameEQ = encodeURIComponent(name) + "=";
    const cookies = document.cookie.split(';');
    for (let i = 0; i < cookies.length; i++) {
        let cookie = cookies[i].trim();
        if (cookie.startsWith(nameEQ)) {
            return decodeURIComponent(cookie.substring(nameEQ.length));
        }
    }
    return null;
}
function removeCookie(name) {
    document.cookie = encodeURIComponent(name) + "=; Expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/";
}
