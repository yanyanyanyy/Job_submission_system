import axios from 'axios'        //引入 axios库
import qs from 'qs'              //引入 node中自带的qs模块（数据格式转换）

/* 2.全局默认配置 */
let baseURL
// 判断开发环境（一般用于本地代理）
baseURL = 'https://localhost:7294/'

// 配置axios的属性
axios.defaults.timeout = 6000;    // 请求超时时间1分钟                  
axios.defaults.baseURL = baseURL; // 你的接口地址 
axios.defaults.responseType = "json";
axios.defaults.withCredentials = false;  //是否允许带cookie这些

export default axios 