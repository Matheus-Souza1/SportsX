export const getClassification = (value) => {
    if (value == 1) {
        return 'Ativo'
    }
    else if (value == 2) {
        return 'Inativo'
    }
    else if (value == 3) {
        return 'Preferencial'
    }

    return '';
};

export const getLabel = (value) => {
    if (value == 1) {
        return 'success'
    }
    else if (value == 2) {
        return 'error'
    }
    else if (value == 3) {
        return 'info'
    }

    return '';
};



