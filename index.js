function treeVisualizer(root, leftBranch, rightBranch) {
    var result = " ".repeat(leftBranch.length + 1) + root;
    var countTextRight = 0;
    for (var i = 0; i <= leftBranch.length && i <= rightBranch.length; i++) {
        var textRight = "";
        if (i == 0)
            textRight = (" ")
        else {
            countTextRight += 2;
            textRight = (" ").repeat(i + countTextRight)
        }
        result += "\n" + (" ").repeat(leftBranch.length - i) + (leftBranch[i] ?? " ") + textRight + (rightBranch[i] ?? " ")
    }

    console.log(result);
}

function createTree(array) {
    var bigger = 0;
    var index = 0;
    var right = [];
    var left = [];

    array.forEach((n, i) => {
        if (n > bigger) {
            bigger = n;
            index = i + 1;
        }
    });

    right = array.slice(index, array.length).sort(function (a, b) { return b - a })
    left = array.slice(0, index - 1).sort(function (a, b) { return b - a });

    console.log("Array de Entrada: ", array);
    console.log("Raiz: ", bigger);
    console.log("Galhos da Esquerda: ", left);
    console.log("Galhos da Direita: ", right);

    treeVisualizer(bigger, left, right);
}


createTree([3, 2, 1, 6, 0, 5]);
