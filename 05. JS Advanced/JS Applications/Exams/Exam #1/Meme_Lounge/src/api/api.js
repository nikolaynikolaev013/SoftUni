// import {notify} from '../notification.js';

export const settings = {
    host : ''
}

async function request(url, options) {
try {
    const response = await fetch(url, options);

    if (response.ok == false) {
        console.log(response.json)
        const error = await response.json();
        throw new Error(error.message);
    }

    try {
        const data = await response.json();
        return data;
    }catch(err){
        return response;
    }
}catch(err) {
    alert(err.message); /*  change alert with notify for notification   */
    throw err;
}
}

function getOption(method = 'get', body) {
    const options = {
        method,
        headers: {}
    };

    const token = sessionStorage.getItem('authToken');
    if (token != null) {
        options.headers['X-Authorization'] = token;
    }

    if (body) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(body);
    }

    return options;
}

export async function get(url) {
    return await request(url, getOption());
}

export async function post(url, data) {
    return await request(url, getOption('post', data));
}

export async function put(url, data) {
    return await request(url, getOption('put', data));
}

export async function del(url, data) {
    return await request(url, getOption('delete'));
}

export async function login(email, password) {
    const result = await post(settings.host + '/users/login', {email, password});

    sessionStorage.setItem('email', result.email);
    sessionStorage.setItem('authToken', result.accessToken);
    sessionStorage.setItem('userId', result._id);
    sessionStorage.setItem('gender', result.gender);
    sessionStorage.setItem('username', result.username);
    return result;
}

export async function register( email, password, username, gender ) {
    const result = await post(settings.host + '/users/register', {email, password, username, gender});

    sessionStorage.setItem('email', result.email);
    sessionStorage.setItem('authToken', result.accessToken);
    sessionStorage.setItem('userId', result._id);
    sessionStorage.setItem('gender', result.gender);
    sessionStorage.setItem('username', result.username);
    

    return result;
}

export async function logout() {
    const result = await get(settings.host + '/users/logout');

    sessionStorage.removeItem('email' );
    sessionStorage.removeItem('authToken');
    sessionStorage.removeItem('userId');
    sessionStorage.removeItem('gender');
    sessionStorage.removeItem('username');

    return result;
}