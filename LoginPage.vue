

<template>
  <!--一个登录界面-->
  <div>

    <h1>欢迎使用本系统！</h1>    
    <!--选择身份的下拉框---->
    <div>
      请选择您的身份:
      <el-select v-model="state" class="m-2" placeholder="Select">
    <el-option
      v-for="item in userId"
      :key="item.value"
      :label="item.label"
      :value="item.value"
    />
  </el-select>
    </div>

    <div> 
      账号：
      <el-input v-model="userid" placeholder="请输入账号" />
    </div>
    
    <div>
    <label>密码</label>
    <el-input
    v-model="password"
    type="password"
    placeholder="请输入密码"
    show-password
    />
    </div>
    
    <p>如果没有注册将会在本系统中自动注册</p>
    <!-- 这里点击登录/注册将会跳转至对应的界面 -->
    <el-button type="success">登录/注册</el-button>  

  </div>
</template>

<script>
    export default{
        data(){
            return{
              userId:[
                {
                  value: "teacher",
                  label: "教师"
                },
                {
                  value: "student",
                  label: "学生"
                }
              ],
              //TODO: 将UserName和PassWord传递给后端,后端通过UserName和PassWord判断是否存在该用户，如果存在则登录，如果不存在则注册
              userid: "",
              password: "",
              //TODO: 将LoginState传递给后端,state有两种取值，一种是teacher，一种是student，传递给后端决定了跳转的界面
              state:"",
            }
        },
        methods:{
          
            
        }
    } 
</script>

<style scoped>

</style>
