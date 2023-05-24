<template>
    <!--本页面是教师点击发布作业按钮之后跳转到的页面-->
    <div>请您发布作业！</div>
    <br>
    <div>
      发布班级：
    <!--适用广泛的基础单选 v-model 的值为当前被选中的 el-option 的 value 属性值-->
    <el-select v-model="classNumPolished" class="m-2" placeholder="请选择要发布的班级">
          <el-option
            v-for="item in classNumPolish"
            :key="item.value"
            :label="item.label"
            :value="item.value"
          />
    </el-select>
  
    </div>    
  
    <br>
  
    <div>
      作业标题/简介：
      <el-input v-model="polishText" placeholder="请输入内容  " clearable />
      
    </div>
  
    <br>
  
    <!--截止日期控件，但是功能没做好，不知道选择的日期传递到哪里去-->
    <div>
      <div class="block">
        <span class="demonstration">请设置截止日期：</span>
        <el-date-picker
          v-model="value2"
          type="datetime"
          placeholder="请选择截止时间"
          :shortcuts="shortcuts"
        />
      
    </div>
  
    <br>
    <!--上传附件-->
    <div>
      请上传附件：
      <el-upload
      v-model:file-list="fileList"
      class="upload-demo"
      action="https://run.mocky.io/v3/9d059bf9-4660-45f2-925d-ce80ad6c4d15"
      multiple
      :on-preview="handlePreview"
      :on-remove="handleRemove"
      :before-remove="beforeRemove"
      :limit="3"
      :on-exceed="handleExceed"
    >
      <el-button type="primary">Click to upload</el-button>
      <template #tip>
        <div class="el-upload__tip">
          jpg/png文件不能超过500KB
        </div>
      </template>
    </el-upload>
    </div>
    </div>
    
    <br>
    <!--点击发布作业之后会跳转到作业列表页面,功能未实现-->
    <div>
      <el-button type="success" round>点击发布作业</el-button>
    </div>
    
    <!--返回按钮-->
<el-button type="info">返回上一页</el-button>
  </template>
  
  <script>
    export default{
      data(){
        return{
          //TODO:发布作业的班级号，如果有时间的话可以完善，后端向classNum传输数据
          classNumPolish:[
        {
          value: 'class1',
          label: 'class1',
        },
        {
          value: 'class2',
          label: 'class2',
        },
        {
          value: 'class3',
          label: 'class3',
        },
        {
          value: 'class4',
          label: 'class4',
        },
        {
          value: 'class5',
          label: 'class5',
        },
      ],
      //TODO:老师选中要发布的班级号，classNumPolished为向后端传输的数据
      classNumPolished:"",
  
      //TODO:发布作业的标题/简介
      polishText:"",
        }
      },
      
  
      methods:{
        
      }
    }
  </script>
  
  <style>
  
  </style>