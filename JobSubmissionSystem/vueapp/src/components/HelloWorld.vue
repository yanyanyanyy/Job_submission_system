<template>
    <div class="home">
        <div   v-for="d in t">
            <p >{{d.content}}</p>
            <div v-show ="{{d.xuanzhong}}">
                <input />
            </div>
        </div>
    </div>
</template>
<script>
    import axios from '../../api/config' //引入 node中自带的qs模块（对application/x-www-form-urlencoded数据格式转换）
    export default {
        name: 'HelloWorld',
        data() {
            return {
                t: [{
                    "content": "HelloWorld",
                    "pizhu": "好的"
                    "xuanzhong"; false,
                    "xiugai":true
                },
                 {
                    "content": "HelloWorld",
                    "pizhu": "好的"
                    "xuanzhong"; false
                }],// getItemList  接口入参
            }
        },
        created() {
            //axios.get('/api/login/Getuser').then(
              //  response => (this.data = response.data)
            //)
            
        }
    }
</script> 