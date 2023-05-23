

<template>
  <!--一个登录界面-->
  <div>

    <h1>欢迎使用本系统！</h1>    
    <!--选择身份的下拉框---->
    <div>
      <p>请选择您的身份</p>
      <select name="LoginState" v-model="state" @change="getvaluemethod($event)">
        <!-- 两个身份，一个是教师，一个是学生，选择某个身份就会传递参数给state -->
        <!-- 默认选中教师选项 -->
        <option value="teacher">教师</option>
        <option value="student">学生</option>
      </select>
    </div>

    <div> 
      <label>用户名</label>
      <input type="text" v-model="username">
    </div>
    
    <div>
    <label>密码</label>
    <input type="password" v-model="password">
    </div>
    
    <p>如果没有注册将会在本系统中自动注册</p>
    <!-- 这里点击登录/注册将会跳转至对应的界面 -->
    <button onclick="window.location.href='/view/LoginPage'">登录/注册</button>
    
    
    <!-- 
      测试这三个值有没有被正确的传递
    <p>{{ state }}</p>
    <p>{{ username }}</p>
    <p>{{ password }}</p> 
    -->
  </div>
</template>

<script>
    export default{
        data(){
            return{

              //TODO: 将UserName和PassWord传递给后端,后端通过UserName和PassWord判断是否存在该用户，如果存在则登录，如果不存在则注册
              username: "",
              password: "",
              //TODO: 将LoginState传递给后端,state有两种取值，一种是teacher，一种是student，传递给后端决定了跳转的界面
              state:"",
            }
        },
        methods:{
          //获取下拉框选中的值并赋值给state
          getvaluemethod: function(event) {
					//获取当前选中的值，并重新赋值
					_this.state = event.target.value;
				}
            
        }
    } 
</script>

<style scoped>

</style>
