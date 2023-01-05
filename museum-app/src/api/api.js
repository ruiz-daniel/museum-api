/* eslint-disable import/no-anonymous-default-export */
import axios from 'axios'
import NProgress from 'nprogress'

export const apiClient = axios.create({
  baseURL: 'http://localhost:5225/api/',
  headers: {
    'Content-Type': 'application/json',
  },
})

// Interceptors to initiate and stop progress bar during axios requests
apiClient.interceptors.request.use((config) => {
  NProgress.start()
  return config
})

apiClient.interceptors.response.use(
  (response) => {
    NProgress.done()
    return response
  },
  function (error) {
    NProgress.done()
    return Promise.reject(error)
  },
)

export default {
  getMuseums(callback) {
    apiClient
      .request({ method: 'get', url: 'Museum' })
      .then((response) => {
        if (callback) callback(response.data)
      })
      .catch((error) => {
        console.log(error)
      })
  },
  getMuseum(id, callback) {
    apiClient
      .request({
        method: 'get',
        url: `Museum/${id}`,
      })
      .then((response) => {
        callback(response.data)
      })
      .catch((error) => {
        alert(error.response.data)
        console.log(error)
      })
  },
  getMuseumsByTheme(theme, callback) {
    apiClient
      .request({
        method: 'get',
        url: `Museum/theme/${theme}`,
      })
      .then((response) => {
        callback(response.data)
      })
      .catch((error) => {
        alert(error.response.data)
        console.log(error)
      })
  },
  createMuseum(museum, callback) {
    apiClient
      .request({
        method: 'post',
        url: 'Museum/',
        data: museum,
      })
      .then((response) => {
        callback(response.data)
      })
      .catch((error) => {
        alert(error.response.data)
        console.log(error)
      })
  },
  updateMuseum(museum, callback) {
    apiClient
      .request({
        method: 'put',
        url: 'Museum/',
        data: museum,
      })
      .then((response) => {
        callback(response.data)
      })
      .catch((error) => {
        alert(error.response.data)
        console.log(error)
      })
  },
  deleteMuseum(id, callback) {
    apiClient
      .request({
        method: 'delete',
        url: `Museum/${id}`,
      })
      .then((response) => {
        callback(response.data)
      })
      .catch((error) => {
        alert(error.response.data)
        console.log(error)
      })
  },
  getArticles(callback) {
    apiClient
      .request({ method: 'get', url: 'Article' })
      .then((response) => {
        if (callback) callback(response.data)
      })
      .catch((error) => {
        console.log(error)
      })
  },
  getArticlesByMuseum(museum, callback) {
    apiClient
      .request({ method: 'get', url: `Article/museum/${museum}` })
      .then((response) => {
        if (callback) callback(response.data)
      })
      .catch((error) => {
        console.log(error)
      })
  },
  createArticle(article, callback) {
    apiClient
      .request({
        method: 'post',
        url: 'Article/',
        data: article,
      })
      .then((response) => {
        callback(response.data)
      })
      .catch((error) => {
        console.log(error)
      })
  },
  updateArticle(article, callback) {
    apiClient
      .request({
        method: 'put',
        url: 'Article/',
        data: article,
      })
      .then((response) => {
        callback(response.data)
      })
      .catch((error) => {
        console.log(error)
      })
  },
  deleteArticle(id, callback) {
    apiClient
      .request({
        method: 'delete',
        url: `Article/${id}`,
      })
      .then((response) => {
        callback(response.data)
      })
      .catch((error) => {
        alert(error.response.data)
        console.log(error)
      })
  }
}
