// If INT
if (entry.substring(0, 4) == "INT.") {
    lines.push(
        "<p style='font-weight: bold;" +
        style + "'>" + entry + "</p>\n");
}

else if (entry == entry.toUpperCase()) {
    lines.push(
        "<p style='text-align: center; font-weight: bold;" +
        style + "'>" + entry + "</p>\n");
}

// Default
else {
    lines.push("<p style='" +
        style + "'> " + entry + "</p><br>\n");
}